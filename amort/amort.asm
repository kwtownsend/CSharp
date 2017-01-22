;========1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3=========4=========5=========6=========7**
;Author information
;  Author name: Kendall Townsend
;  Author email: kendallcar@csu.fullerton.edu
;  Author location: CSUF
;Course information
;  Course number: CPSC240
;  Assignment number: 3
;  Due date: 2014-Sep-29
;Project information
;  Project title: Amortization Schedule
;  Purpose: Inputting 4 loans with %interest and amount of months and generating an amort schedule
;  Status: No known errors
;  Project files: amort.cpp, amort.asm, amortfunc.cpp
;Module information
;  This module's call name: amort	
;  Language: X86-64
;  Syntax: Intel
;  Date last modified: 2014-Sep-28
;  Purpose: To learn how to use c++ functions and for loops in assembly
;  File name: amort.asm
;  Status: This module functions as expected as a demonstrator.
;  Future enhancements: None planned
;Translator information
;  Linux: nasm -f elf64 -l amort.lis -o amort.o amort.asm
;References and credits
;  holliday fp-io project
;Format information
;  Page width: 172 columns
;  Begin comments: 61
;  Optimal print specification: Landscape, 7 points or smaller, monospace, 8½x11 paper
;
;===== Begin code area ====================================================================================================================================================

extern amortfunc

extern printf                                               ;External C++ function for writing to standard output device

extern scanf                                                ;External C++ function for reading from the standard input device

global amort                                                ;This makes amort callable by functions outside of this file.

segment .data                                               ;Place initialized data here


;===== Declare some messages ==============================================================================================================================================


startupmessage db "Welcome to the Bank of Kendall Island ", 10, 0

followupmessage db "Kendall Townsend, Chief Loan Officer ", 10, 0

promptmessage1 db "Please enter the current interest rate as a float number: ", 0

promptmessage2 db "Enter the amount of the first loan: ", 0

promptmessage3 db "Enter the amount of the second loan: ", 0

promptmessage4 db "Enter the amount of the third loan: ", 0

promptmessage5 db "Enter the amount of the fourth loan: ", 0

promptmessage6 db "Enter the time of the loans as a whole number of months: ", 0

postdatamessage db "Condensed amortization schedules for the four possible loans are as follows. ", 10, 0

answermessage1 db "Loan amounts :           %10.2lf %10.2lf %10.2lf %10.2lf", 10, 0

answermessage2 db "Monthly payment amount: %10.2lf %10.2lf %10.2lf %10.2lf", 10, 0

answermessage3 db "interest due by months", 10, 0

answermessage4 db "                    %2.0lf  %10.2lf %10.2lf %10.2lf %10.2lf", 10, 0

answermessage5 db "Total interest :        %10.2lf %10.2lf %10.2lf %10.2lf", 10, 0
  
closingmessage db "Thank you for your inquiry at our bank.", 10, 0

closingmessage2 db "This program will now return the total interest of the last loan to the driver.", 10, 0

xsavenotsupported.notsupportedmessage db "The xsave instruction and the xrstor instruction are not supported in this microprocessor.", 10
                                      db "However, processing will continue without backing up state component data", 10, 0



stringformat db "%s", 0                                     ;general string format

xsavenotsupported.stringformat db "%s", 0

eight_byte_format db "%lf", 0                               ;general 8-byte float format

segment .bss                                                ;Place un-initialized data here.

align 64                                                    ;Insure that the inext data declaration starts on a 64-byte boundar.
backuparea resb 832                                         ;Create an array for backup storage having 832 bytes.

align 64                                                    ;Insure that the inext data declaration starts on a 64-byte boundar.
localbackuparea resb 832                                    ;Create an array for backup storage having 832 bytes.

;===== Begin executable instructions here =================================================================================================================================

%include "debug.inc"

segment .text                                               ;Place executable instructions in this segment.

amort:                                                      ;Entry point.  Execution begins here.

;=========== Back up all the GPRs whether used in this program or not =====================================================================================================

push       rbp                                              ;Save a copy of the stack base pointer
mov        rbp, rsp                                         ;We do this in order to be 100% compatible with C and C++.
push       rbx                                              ;Back up rbx
push       rcx                                              ;Back up rcx
push       rdx                                              ;Back up rdx
push       rsi                                              ;Back up rsi
push       rdi                                              ;Back up rdi
push       r8                                               ;Back up r8
push       r9                                               ;Back up r9
push       r10                                              ;Back up r10
push       r11                                              ;Back up r11
push       r12                                              ;Back up r12
push       r13                                              ;Back up r13
push       r14                                              ;Back up r14
push       r15                                              ;Back up r15
pushf                                                       ;Back up rflags


;==========================================================================================================================================================================
;===== Begin State Component Backup =======================================================================================================================================
;==========================================================================================================================================================================

;=========== Before proceeding verify that this computer supports xsave and xrstor ========================================================================================
;Bit #26 of rcx, written rcx[26], must be 1; otherwise xsave and xrstor are not supported by this computer.
;Preconditions: rax holds 1.
mov        rax, 1

;Execute the cpuid instruction
cpuid

;Postconditions: If rcx[26]==1 then xsave is supported.  If rcx[26]==0 then xsave is not supported.

;=========== Extract bit #26 and test it ==================================================================================================================================

and        rcx, 0x0000000004000000                          ;The mask 0x0000000004000000 has a 1 in position #26.  Now rcx is either all zeros or
                                                            ;has a single 1 in position #26 and zeros everywhere else.
cmp        rcx, 0                                           ;Is (rcx == 0)?
je         xsavenotsupported                                ;Skip the section that backs up state component data.

;========== Call the function to obtain the bitmap of state components ====================================================================================================

;Preconditions
mov        rax, 0x000000000000000d                          ;Place 13 in rax.  This number is provided in the Intel manual
mov        rcx, 0                                           ;0 is parameter for subfunction 0

;Call the function
cpuid                                                       ;cpuid is an essential function that returns information about the cpu

;Postconditions (There are 2 of these):

;1.  edx:eax is a bit map of state components managed by xsave.  At the time this program was written (2014 June) there were exactly 3 state components.  Therefore, bits
;    numbered 2, 1, and 0 are important for current cpu technology.
;2.  ecx holds the number of bytes required to store all the data of enabled state components. [Post condition 2 is not used in this program.]
;This program assumes that under current technology (year 2014) there are at most three state components having a maximum combined data storage requirement of 832 bytes.
;Therefore, the value in ecx will be less than or equal to 832.

;Precaution: As an insurance against a future time when there will be more than 3 state components in a processor of the X86 family the state component bitmap is masked to
;allow only 3 state components maximum.

mov        r15, 7                                           ;7 equals three 1 bits.
and        rax, r15                                         ;Bits 63-3 become zeros.
mov        r15, 0                                           ;0 equals 64 binary zeros.
and        rdx, r15                                         ;Zero out rdx.

;========== Save all the data of all three components except GPRs =========================================================================================================

;The instruction xsave will save those state components with on bits in the bitmap.  At this point edx:eax continues to hold the state component bitmap.

;Precondition: edx:eax holds the state component bit map.  This condition has been met by the two pops preceding this statement.
xsave      [backuparea]                                     ;All the data of state components managed by xsave have been written to backuparea.

push qword -1                                               ;Set a flag (-1 = true) to indicate that state component data were backed up.
jmp        startapplication

;========== Show message xsave is not supported on this platform ==========================================================================================================
xsavenotsupported:

mov        rax, 0
mov        rdi, .stringformat
mov        rsi, .notsupportedmessage                        ;"The xsave instruction is not suported in this microprocessor.
call       printf

push qword 0                                                ;Set a flag (0 = false) to indicate that state component data were not backed up.

;==========================================================================================================================================================================
;===== End of State Component Backup ======================================================================================================================================
;==========================================================================================================================================================================


;==========================================================================================================================================================================
startapplication: ;===== Begin the application here: demonstrate floating point i/o =======================================================================================
;==========================================================================================================================================================================



;=========== Show the startup message =====================================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, startupmessage                              ;"Welcome to the Bank of Kendall Island "
call       printf                                           ;Call a library function to make the output

;=========== Show the followup message =====================================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, followupmessage                             ;"Kendall Townsend, Chief Loan Officer "
call       printf                                           ;Call a library function to make the output



;=========== Prompt for floating point number =============================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, promptmessage1                              ;"Please enter the current interest rate as a float number: "
call       printf                                           ;Call a library function to make the output


;===== how to input one float number=============================================================================

push qword 0                                                ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                           ;SSE is not involved in this scanf operation
mov          rdi, eight_byte_format                         ;"%lf"
mov          rsi, rsp                                       ;Give scanf a point to the reserved storage
call         scanf                                          ;Call a library function to do the input work
vbroadcastsd ymm14, [rsp]                                   ;Copy the inputted number to ymm8
pop           rax                                           ;Make free the storage that was used by scanf


;=========== Prompt for floating point number =============================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, promptmessage2                              ;"Enter the amount of the first loan: "
call       printf                                           ;Call a library function to make the output


;===== how to input one float number=============================================================================

push qword 0                                                ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                           ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                           ;"%lf"
mov        rsi, rsp                                         ;Give scanf a point to the reserved storage
call       scanf                                            ;Call a library function to do the input work



;=========== Prompt for floating point number =============================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, promptmessage3                              ;"Enter the amount of the second loan: "
call       printf                                           ;Call a library function to make the output


;===== how to input one float number=============================================================================

push qword 0                                                ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                           ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                           ;"%lf"
mov        rsi, rsp                                         ;Give scanf a point to the reserved storage
call       scanf                                            ;Call a library function to do the input work


;=========== Prompt for floating point number =============================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, promptmessage4                              ;"Enter the amount of the third loan: "
call       printf                                           ;Call a library function to make the output

;===== how to input one float number=============================================================================

push qword 0                                                ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                           ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                           ;"%lf"
mov        rsi, rsp                                         ;Give scanf a point to the reserved storage
call       scanf                                            ;Call a library function to do the input work


;=========== Prompt for floating point number =============================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, promptmessage5                              ;"Enter the amount of the fourth loan: "
call       printf                                           ;Call a library function to make the output

;===== how to input one float number=============================================================================

push qword 0                                                ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                           ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                           ;"%lf"
mov        rsi, rsp                                         ;Give scanf a point to the reserved storage
call       scanf                                            ;Call a library function to do the input work

;===== put numbers on stack into ymm15=============================================================================
vmovupd ymm15, [rsp]                                        ;Take loan amounts that were inserted into stack and put them in ymm15

pop           rax                                           ;Make free the storage that was used by scanf
pop           rax                                           ;Make free the storage that was used by scanf
pop           rax                                           ;Make free the storage that was used by scanf
pop           rax                                           ;Make free the storage that was used by scanf

;=========== Prompt for floating point number =============================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, promptmessage6                              ;"Enter the time of the loans as a whole number of months: "
call       printf                                           ;Call a library function to make the output


;===== how to input one float number=============================================================================

push qword 0                                                ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                           ;SSE is not involved in this scanf operation
mov          rdi, eight_byte_format                         ;"%lf"
mov          rsi, rsp                                       ;Give scanf a point to the reserved storage
call         scanf                                          ;Call a library function to do the input work
vbroadcastsd ymm13, [rsp]                                   ;Copy the inputted number to ymm13
pop           rax                                           ;Make free the storage that was used by scanf

;=========== Show the postdata message ====================================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, postdatamessage                             ;"Thank you. The computations have completed with the following results."
call       printf                                           ;Call a library function to make the output



;===== Divide the inputted number by a constant ===========================================================================================================================
vmovupd        ymm7, ymm15                                  ;put loan amounts into a register to prepare for printing

push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number

vmovupd        [rsp], ymm7                                  ;pop off loan amounts into the stack
vbroadcastsd   ymm3, [rsp]                                  ;put first loan amount into ymm3 so that it is ready for printf
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm2, [rsp]                                  ;put second loan amount into ymm2 so that it is ready for printf
pop            rax                                          ;Make free the storage that was used                                     

vbroadcastsd   ymm1, [rsp]                                  ;put third loan amount into ymm1 so that it is ready for printf
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm0, [rsp]                                  ;put fourth loan amount into ymm0 so that it is ready for printf
pop            rax                                          ;Make free the storage that was used


;=========== Show the first answermessage message =========================================================================================================================
push qword 0
mov qword  rax, 4                                           ;No data from SSE will be printed
mov        rdi, answermessage1                              ;"Loan amounts : %23.18lf %23.18lf %23.18lf %23.18lf"
call       printf                                           ;Call a library function to make the output
pop            rax                                          ;Make free the storage that was used by scanf

;===== Use c++ function to solve for monthly payment amt ==================================================================================================================
vmovupd        ymm7, ymm15                                  ;put loan amounts into a register to prepare for input into c++ function

push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number

vmovupd        [rsp], ymm7                                  ;pop off loan amounts into the stack
vbroadcastsd   ymm8, [rsp]                                  ;put first loan amount into ymm3 so that it is ready for c++ function
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm9, [rsp]                                  ;put second loan amount into ymm3 so that it is ready for c++ function
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm10, [rsp]                                 ;put third loan amount into ymm3 so that it is ready for c++ function
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm11, [rsp]                                 ;put four loan amount into ymm3 so that it is ready for c++ function
pop            rax                                          ;Make free the storage that was used


push qword 0
vmovupd      xmm1, xmm14                                    ;variable 'i' interest put into xmm1 for c++ func
vmovupd      xmm2, xmm8                                     ;variable 'p' principle put into xmm2 for c++ func
vmovupd      xmm3, xmm13                                    ;variable 'n' months put into xmm3 for c++ func
call amortfunc                                              ;calling c++ function to solve monthly payment amount with given variables
movsd      [rsp], xmm0                                      ;retrieve monthly payment amount from xmm0 and put it in stack


push qword 0
vmovupd      xmm1, xmm14                                    ;variable 'i' interest put into xmm1 for c++ func
vmovupd      xmm2, xmm9                                     ;variable 'p' principle put into xmm2 for c++ func
vmovupd      xmm3, xmm13                                    ;variable 'n' months put into xmm3 for c++ func
call amortfunc                                              ;calling c++ function to solve monthly payment amount with given variables
movsd      [rsp], xmm0                                      ;retrieve monthly payment amount from xmm0 and put it in stack


push qword 0
vmovupd      xmm1, xmm14                                    ;variable 'i' interest put into xmm1 for c++ func
vmovupd      xmm2, xmm10                                    ;variable 'p' principle put into xmm2 for c++ func
vmovupd      xmm3, xmm13                                    ;variable 'n' months put into xmm3 for c++ func
call amortfunc                                              ;calling c++ function to solve monthly payment amount with given variables
movsd      [rsp], xmm0                                      ;retrieve monthly payment amount from xmm0 and put it in stack


push qword 0
vmovupd      xmm1, xmm14                                    ;variable 'i' interest put into xmm1 for c++ func
vmovupd      xmm2, xmm11                                    ;variable 'p' principle put into xmm2 for c++ func
vmovupd      xmm3, xmm13                                    ;variable 'n' months put into xmm3 for c++ func
call amortfunc                                              ;calling c++ function to solve monthly payment amount with given variables
movsd      [rsp], xmm0                                      ;retrieve monthly payment amount from xmm0 and put it in stack

vmovupd ymm12, [rsp]

pop            rax                                          ;Make free the storage that was used
pop            rax                                          ;Make free the storage that was used
pop            rax                                          ;Make free the storage that was used
pop            rax                                          ;Make free the storage that was used

;===== Prepare for printf =================================================================================================================================================
vmovupd        ymm7, ymm12                                  ;put monthly payment amount into a free ymm register to prepare for printing

push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number

vmovupd        [rsp], ymm7                                  ;pop off monthly payment amounts into stack
vbroadcastsd   ymm0, [rsp]                                  ;put first amount into ymm0
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm1, [rsp]                                  ;put second amount into ymm1
pop            rax                                          ;Make free the storage that was used
 
vbroadcastsd   ymm2, [rsp]                                  ;put third amount into ymm2
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm3, [rsp]                                  ;put fourth amount into ymm3
pop            rax                                          ;Make free the storage that was used

;=========== Show answermessage2 ==========================================================================================================================================
push qword 0
mov qword  rax, 4                                           ;No data from SSE will be printed
mov        rdi, answermessage2                              ;"Loan amounts : %23.18lf %23.18lf %23.18lf %23.18lf"
call       printf                                           ;Call a library function to make the output
pop            rax                                          ;Make free the storage that was used by scanf

;=========== Show answermessag3 ===========================================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, answermessage3                              ;"Interest due by months:"
call       printf                                           ;Call a library function to make the output


;=========== for loop to find interest due by months ======================================================================================================================

mov        rbx, 0x0000000000000000                          ;Constant 0x4000000000000000 = 0.0 (decimal).
push       rbx                                              ;Place the constant on the integer stack
movsd      xmm11, [rsp]                                     ;take the number 0 from stack and put it into xmm11
pop            rax                                          ;Make free the storage that was used

mov        rbx, 0x3FF0000000000000                          ;Constant 0x3FF0000000000000 = 1.0 (decimal).
push       rbx                                              ;Place the constant on the integer stack
movsd      xmm10, [rsp]                                     ;take the number 1 from stack and put it into xmm10
pop            rax                                          ;Make free the storage that was used





vmovupd        ymm6, ymm15                                  ;prepare loan amounts variable for loop
vmovupd        ymm7, ymm15                                  ;prepare a separate loan amount variable for loop
vmovupd        ymm8, ymm14                                  ;prepare %interest variable for loop
vmovupd        ymm9, ymm12                                  ;prepare monthly payment amount variable for loop

for:                                                        ;bookmarker for the for loop

vmovupd        ymm7, ymm6                                   ;reset the loan amount values to default

vmulpd         ymm7, ymm8                                   ;multiply the loan amount by %interest
vsubpd         ymm6, ymm7                                   ;subtract the loan amount by (loan amount * %interest)

vaddpd         ymm5, ymm7                                   ;add a free value by the number previously obtained for later printing purposes





addsd       xmm11, xmm10                                    ;increment counter
movsd       xmm0, xmm11                                     ;put counter in xmm0 for printing


push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number

vmovupd        [rsp], ymm7                                  ;put previously obtained number into stack for printing
vbroadcastsd   ymm4, [rsp]                                  ;put first number from stack into ymm4
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm3, [rsp]                                  ;put second number from stack into ymm3
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm2, [rsp]                                  ;put third number from stack into ymm2
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm1, [rsp]                                  ;put fourth number from stack into ymm1
pop            rax                                          ;Make free the storage that was used

mov rdx, 0                                                  ;prepare for xsave
mov rax, 7                                                  ;prepare for xsave
xsave  [localbackuparea]                                    ;back up registers since printf will remove them

push qword 0
mov qword  rax, 5                                           ;No data from SSE will be printed
mov        rdi, answermessage4                              ;"%s"
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf

mov rdx, 0                                                  ;prepare for xrstor
mov rax, 7                                                  ;prepare for xrstor
xrstor  [localbackuparea]                                   ;restore lost registers :)

ucomisd     xmm11, xmm13                                    ;compare counter and how many months are needed
jne         for                                             ;if counter isn't equal to months go back to for bookmarker
jmp         outofloop                                       ;if they are equal exit loop
outofloop:                                                  ;bookmarker to exit loop



;=========== prepare for printf ===========================================================================================================================================
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number


vmovupd        [rsp], ymm5                                  ;take total interest amount and put it into stack
vbroadcastsd   ymm3, [rsp]                                  ;put first total interest variable into ymm3 from stack
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm2, [rsp]                                  ;put second total interest variable into ymm2 from stack
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm1, [rsp]                                  ;put third total interest variable into ymm1 from stack
pop            rax                                          ;Make free the storage that was used

vbroadcastsd   ymm0, [rsp]                                  ;put fourth total interest variable into ymm0 from stack
pop            rax                                          ;Make free the storage that was used

mov rdx, 0                                                  ;prepare for xsave
mov rax, 7                                                  ;prepare for xsave
xsave  [localbackuparea]                                    ;back up registers since printf will remove them



;=========== Show answermessage5 ==========================================================================================================================================
push qword 0
mov qword  rax, 4                                           ;No data from SSE will be printed
mov        rdi, answermessage5                              ;Total interest :        %10.2lf %10.2lf %10.2lf %10.2lf
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf

;=========== Show answermessage5 ==========================================================================================================================================
push qword 0
mov qword  rax, 4                                           ;No data from SSE will be printed
mov        rdi, closingmessage                              ;"Thank you for your inquiry at our bank"
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf

;=========== Show answermessage5 ==========================================================================================================================================
push qword 0
mov qword  rax, 4                                           ;No data from SSE will be printed
mov        rdi, closingmessage2                             ;"This program will now return the total interest of the last loan to the driver."
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf



;===== Save a copy of the area before calling printf ======================================================================================================================
mov rdx, 0                                                  ;prepare for xrstor
mov rax, 7                                                  ;prepare for xrstor
xrstor  [localbackuparea]                                   ;restore lost registers :)

push qword 0                                                ;Reserve 8 bytes of storage
movsd      [rsp], xmm3                                      ;Place a backup copy of the quotient in the reserved storage

;===== Retrieve a copy of the quotient that was backed up earlier =========================================================================================================

pop        r14                                              ;A copy of the quotient is in r14 (temporary storage)

;Now the stack is in the same state as when the application area was entered.  It is safe to leave this application area.



;==========================================================================================================================================================================
;===== Begin State Component Restore ======================================================================================================================================
;==========================================================================================================================================================================

;===== Check the flag to determine if state components were really backed up ==============================================================================================

pop        rbx                                              ;Obtain a copy of the flag that indicates state component backup or not.
cmp        rbx, 0                                           ;If there was no backup of state components then jump past the restore section.
je         setreturnvalue                                   ;Go to set up the return value.

;Continue with restoration of state components;

;Precondition: edx:eax must hold the state component bitmap.  Therefore, go get a new copy of that bitmap.

;Preconditions for obtaining the bitmap from the cpuid instruction
mov        rax, 0x000000000000000d                          ;Place 13 in rax.  This number is provided in the Intel manual
mov        rcx, 0                                           ;0 is parameter for subfunction 0

;Call the function
cpuid                                                       ;cpuid is an essential function that returns information about the cpu

;Postcondition: The bitmap in now in edx:eax

;Future insurance: Make sure the bitmap is limited to a maximum of 3 state components.
mov        r15, 7
and        rax, r15
mov        r15, 0
and        rdx, r15

xrstor     [backuparea]
;==========================================================================================================================================================================
;===== End State Component Restore ========================================================================================================================================
;==========================================================================================================================================================================


setreturnvalue: ;=========== Set the value to be returned to the caller ===================================================================================================

push       r14                                              ;r14 continues to hold the first computed floating point value.
movsd      xmm0, [rsp]                                      ;That first computed floating point value is copied to xmm0[63-0]
pop        r14                                              ;Reverse the push of two lines earlier.

;=========== Restore GPR values and return to the caller ==================================================================================================================

popf                                                        ;Restore rflags
pop        r15                                              ;Restore r15
pop        r14                                              ;Restore r14
pop        r13                                              ;Restore r13
pop        r12                                              ;Restore r12
pop        r11                                              ;Restore r11
pop        r10                                              ;Restore r10
pop        r9                                               ;Restore r9
pop        r8                                               ;Restore r8
pop        rdi                                              ;Restore rdi
pop        rsi                                              ;Restore rsi
pop        rdx                                              ;Restore rdx
pop        rcx                                              ;Restore rcx
pop        rbx                                              ;Restore rbx
pop        rbp                                              ;Restore rbp

ret                                                         ;No parameter with this instruction.  This instruction will pop 8 bytes from
                                                            ;the integer stack, and jump to the address found on the stack.
;========== End of program trapezoid.asm ======================================================================================================================================
;========1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3=========4=========5=========6=========7**
