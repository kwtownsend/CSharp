;========1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3=========4=========5=========6=========7**
;Author information
;  Author name: Kendall Townsend
;  Author email: kendallcar@csu.fullerton.edu
;  Author location: CSUF
;Course information
;  Course number: CPSC240
;  Assignment number: 2
;  Due date: 2014-Sep-10
;Project information
;  Project title: Electric Circuits in Parallel
;  Purpose: Learn how to use some of the instruction acting on the avx component.
;  Status: No known errors
;  Project files: ec.cpp, ec.asm
;Module information
;  This module's call name: ec	
;  Language: X86-64
;  Syntax: Intel
;  Date last modified: 2014-Sep-8
;  Purpose: Find the details on a four-device direct current parallel circuit and compute missing data.
;  File name: ec.asm
;  Status: This module functions as expected as a demonstrator.
;  Future enhancements: None planned
;Translator information
;  Linux: nasm -f elf64 -l ec.lis -o ec.o ec.asm
;References and credits
;  holliday fp-io project
;Format information
;  Page width: 172 columns
;  Begin comments: 61
;  Optimal print specification: Landscape, 7 points or smaller, monospace, 8½x11 paper
;
;===== Begin code area ====================================================================================================================================================

extern printf                                               ;External C++ function for writing to standard output device

extern scanf                                                ;External C++ function for reading from the standard input device

global ec                                                   ;This makes ec callable by functions outside of this file.

segment .data                                               ;Place initialized data here

;===== Declare some messages ==============================================================================================================================================


startupmessage db "Welcome to Electric Circuit Processing by Kendall Townsend ", 10, 0

followupmessage db "This program will help analyze direct current circuis configured in parallel. ", 10, 0

promptmessage1 db "Please enter the voltage of the entire circuit in volts: ", 0

promptmessage2 db "Enter the power consumption of device 1 (watts): ", 0

promptmessage3 db "Enter the power consumption of device 2 (watts): ", 0

promptmessage4 db "Enter the power consumption of device 3 (watts): ", 0

promptmessage5 db "Enter the power consumption of device 4 (watts): ", 0

postdatamessage db "Thank you. The computations have complete with the following results.", 0

answermessage1 db "Circuit total voltage: %1.18lf V", 10, 0

answermessage2 db "Device number:                         1                         2                         3                         4", 10, 0

answermessage3 db "Power (watts):               %5.18lf        %5.18lf        %5.18lf        %5.18lf", 10, 0
  
answermessage4 db "Current (amps):              %5.18lf        %5.18lf        %5.18lf        %5.18lf", 10, 0

answermessage5 db "Total current in the circuit is %1.18lf amps.", 10, 0

answermessage6 db "Total power in the circuit is %1.18lf watts. ", 10, 0


; when using %lf first number before decimal is whitespaces before first number, and second number is amount of decimals.


xsavenotsupported.notsupportedmessage db "The xsave instruction and the xrstor instruction are not supported in this microprocessor.", 10
                                      db "However, processing will continue without backing up state component data", 10, 0

goodbye db "", 0

stringformat db "%s", 0                                     ;general string format

xsavenotsupported.stringformat db "%s", 0

eight_byte_format db "%lf", 0                               ;general 8-byte float format

segment .bss                                                ;Place un-initialized data here.

align 64                                                    ;Insure that the inext data declaration starts on a 64-byte boundar.
backuparea resb 832                                         ;Create an array for backup storage having 832 bytes.

;===== Begin executable instructions here =================================================================================================================================

segment .text                                               ;Place executable instructions in this segment.

ec:                                                         ;Entry point.  Execution begins here.

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



;=========== Show the initial message =====================================================================================================================================

mov qword  rax, 0                                          ;No data from SSE will be printed
mov        rdi, stringformat                               ;"%s"
mov        rsi, startupmessage                             ;"Welcome to Electric Circuit Processing by Kendall Townsend "
call       printf                                          ;Call a library function to make the output

;=========== Show the followup message =====================================================================================================================================

mov qword  rax, 0                                          ;No data from SSE will be printed
mov        rdi, stringformat                               ;"%s"
mov        rsi, followupmessage                            ;"This program will help analyze direct current circuits configured in parallel. "
call       printf                                          ;Call a library function to make the output

;===== Conclusion message =================================================================================================================================================

mov qword  rax, 0                                          ;No data from SSE will be printed
mov        rdi, stringformat                               ;"%s"
mov        rsi, goodbye                                    ;"This summation program will now return to the driver.  Have a nice day."
call       printf                                          ;Call a llibrary function to do the hard work.

;=========== Prompt for voltage input =============================================================================================================================

mov qword  rax, 0                                          ;No data from SSE will be printed
mov        rdi, stringformat                               ;"%s"
mov        rsi, promptmessage1                             ;"Please enter the voltage of the entire circuit in volts: "
call       printf                                          ;Call a library function to make the output


;===== broadcast inputted number into ymm14 =============================================================================

push qword 0                                               ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                          ;SSE is not involved in this scanf operation
mov          rdi, eight_byte_format                        ;"%lf"
mov          rsi, rsp                                      ;Give scanf a point to the reserved storage
call         scanf                                         ;Call a library function to do the input work
vbroadcastsd ymm14, [rsp]                                  ;Copy the inputted number to ymm8
pop           rax                                          ;Make free the storage that was used by scanf


;=========== Prompt for 1st device wattage number =============================================================================================================================

mov qword  rax, 0                                          ;No data from SSE will be printed
mov        rdi, stringformat                               ;"%s"
mov        rsi, promptmessage2                             ;"Enter the power consumption of device 1 (watts): "
call       printf                                          ;Call a library function to make the output


;===== input 1st device wattage number into stack=============================================================================

push qword 0                                               ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                          ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                          ;"%lf"
mov        rsi, rsp                                        ;Give scanf a point to the reserved storage
call       scanf                                           ;Call a library function to do the input work



;=========== Prompt for 2nd device wattage number =============================================================================================================================

mov qword  rax, 0                                          ;No data from SSE will be printed
mov        rdi, stringformat                               ;"%s"
mov        rsi, promptmessage3                             ;"Enter the power consumption of device 2 (watts):"
call       printf                                          ;Call a library function to make the output


;===== input 2nd device wattage number into stack=============================================================================

push qword 0                                               ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                          ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                          ;"%lf"
mov        rsi, rsp                                        ;Give scanf a point to the reserved storage
call       scanf                                           ;Call a library function to do the input work


;=========== Prompt for 3rd device wattage number =============================================================================================================================

mov qword  rax, 0                                          ;No data from SSE will be printed
mov        rdi, stringformat                               ;"%s"
mov        rsi, promptmessage4                             ;"Enter the power consumption of device 3 (watts):"
call       printf                                          ;Call a library function to make the output

;===== input 3rd device watage number into stack=============================================================================

push qword 0                                               ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                          ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                          ;"%lf"
mov        rsi, rsp                                        ;Give scanf a point to the reserved storage
call       scanf                                           ;Call a library function to do the input work


;=========== Prompt for 4th device wattage number =============================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, promptmessage5                              ;"Enter the power consumption of device 4 (watts):"
call       printf                                           ;Call a library function to make the output

;===== input 4th device watage number into stack=============================================================================

push qword 0                                                ;Reserve 8 bytes of storage for the incoming number
mov  qword rax, 0                                           ;SSE is not involved in this scanf operation
mov        rdi, eight_byte_format                           ;"%lf"
mov        rsi, rsp                                         ;Give scanf a point to the reserved storage
call       scanf                                            ;Call a library function to do the input work

;===== put numbers on stack into ymm15=============================================================================
vmovupd ymm15, [rsp]                                        ;copy the inputted numbers on stack into ymm15


pop rax							    ;Make free the storage that was used by scanf
pop rax							    ;Make free the storage that was used by scanf				
pop rax                                                     ;Make free the storage that was used by scanf
pop rax                                                     ;Make free the storage that was used by scanf


;=========== Show the post-data message =====================================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, postdatamessage                             ;"Thank you. The computations have completed with the following results."
call       printf                                           ;Call a library function to make the output

;===== Make a copy of the voltage number so it can be outputted ===========================================================================================================================
vmovupd ymm0, ymm14                                         ;move ymm14 into ymm0 so it can be outputted on screen

;=========== Show the first answer message =====================================================================================================================================
push qword 0
mov qword  rax, 1                                           ;No data from SSE will be printed
mov        rdi, answermessage1                              ;"Circuit total voltage: %1.18lf V"
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf

;=========== Show the second answer message =====================================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, answermessage2                              ;"Device Number: 1 2 3 4"
call       printf                                           ;Call a library function to make the output

;===== Pop off the Wattage numbers and ready them for output ===========================================================================================================================
vmovupd        ymm7, ymm15                                  ;put wall the watt numbers into ymm7

push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number
push           qword 0                                      ;Reserve 8 bytes of storage for the incoming number

vmovupd        [rsp], ymm7                                  ;put ymm7 into the stack
vbroadcastsd   ymm3, [rsp]                                  ;put first stack number into ymm3
pop            rax                                          ;Make free the storage

vbroadcastsd   ymm2, [rsp]                                  ;put second stack number into ymm2
pop            rax                                          ;Make free the storage

vbroadcastsd   ymm1, [rsp]                                  ;put third stack number into ymm1
pop            rax                                          ;Make free the storage   

vbroadcastsd   ymm0, [rsp]                                  ;put fourth stack number into ymm0
pop            rax                                          ;Make free the storage 


;=========== Show the third answer message =====================================================================================================================================
push qword 0
mov qword  rax, 4                                           ;No data from SSE will be printed
mov        rdi, answermessage3                              ;"Power(watts):  5.18%lf 5.18%lf 5.18%lf 5.18%lf"
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf
;===== Divide the wattage values by the voltage ===========================================================================================================================

vmovupd       ymm8, ymm15                                   ;make another copy of watt values
vmovupd       ymm9, ymm14                                   ;make another copy of voltage value
vdivpd        ymm8, ymm9                                    ;divide watts by voltage

push        qword 0                                         ;Reserve 8 bytes of storage for the incoming number
push        qword 0                                         ;Reserve 8 bytes of storage for the incoming number
push        qword 0                                         ;Reserve 8 bytes of storage for the incoming number
push        qword 0                                         ;Reserve 8 bytes of storage for the incoming number

vmovupd       [rsp], ymm8                                   ; pop off first number
vbroadcastsd  ymm9, [rsp]                                   ;put first number into a ymm value
pop           rax                                           ;Make free the storage

vbroadcastsd  ymm10, [rsp]                                  ;put second number into a ymm value
pop           rax                                           ;Make free the storage

vbroadcastsd  ymm11, [rsp]                                  ;put third number into a ymm value
pop           rax

vbroadcastsd  ymm12, [rsp]                                  ;put fourth number into a ymm value
pop         rax                                             ;Make free the storage
vmovupd     ymm3, ymm9                                      ;place the first newly found amp value into ymm3
vmovupd     ymm2, ymm10                                     ;place the first newly found amp value into ymm2
vmovupd     ymm1, ymm11                                     ;place the first newly found amp value into ymm1
vmovupd     ymm0, ymm12                                     ;place the first newly found amp value into ymm0

vaddpd      ymm9, ymm10                                     ;add amps up
vaddpd      ymm9, ymm11                                     ;add amps up
vaddpd      ymm9, ymm12                                     ;add amps up
vmovupd     ymm13, ymm9                                     ;save total amp number

;=========== Show the fourth answer message =====================================================================================================================================

push qword 0
mov qword  rax, 4                                           ;No data from SSE will be printed
mov        rdi, answermessage4                              ;"current(amps):  5.18%lf 5.18%lf 5.18%lf 5.18%lf"
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by printf

;===== prepare total amperage value for output ===========================================================================================================================

vmovupd ymm0, ymm13                                         ;put ymm13 into ymm0 for printing


;=========== Show the fifth answer message =====================================================================================================================================

push qword 0
mov qword  rax, 1                                           ;No data from SSE will be printed
mov        rdi, answermessage5                              ;"Total current in the circuit is %1.18lf amps."
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf

;===== Multiply the total amps by the voltage ===========================================================================================================================
vmulpd     ymm13, ymm14                                     ;multiply added up amps by voltage
vmovupd    ymm0, ymm13                                      ;put watt number into ymm0 for printing



;=========== Show the sixth answer message =====================================================================================================================================

push qword 0
mov qword  rax, 1                                           ;No data from SSE will be printed
mov        rdi, answermessage6                              ;"Total power in the circuit is %1.18lf watts."
call       printf                                           ;Call a library function to make the output
pop        rax                                              ;Make free the storage that was used by scanf

;===== Save a copy of the area before calling printf ==================================================================================================================

push qword 0                                                ;Reserve 8 bytes of storage
movsd      [rsp], xmm13                                     ;Place a backup copy of the quotient in the reserved storage

;===== Goodbye message =================================================================================================================================================

mov qword  rax, 0                                           ;No data from SSE will be printed
mov        rdi, stringformat                                ;"%s"
mov        rsi, goodbye                                     ;"This summation program will now return to the driver.  Have a nice day."
call       printf                                           ;Call a llibrary function to do the hard work.

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
;========== End of program ec.asm ======================================================================================================================================
;========1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3=========4=========5=========6=========7**
