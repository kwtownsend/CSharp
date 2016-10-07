#include <unistd.h>
#include <sys/types.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <fstream>
#include <vector>
using namespace std;

/**
 * Forks children and lets them perform their tasks
 * @param urls - the urls to download
 */
void create_children(vector<string>& urls)
	{	

		/* The process id */

		…

		/* Go through all the URLs */



		{ /* Create a child */


			/* Success? */
	

			/* The child code */
	
			fclose(stdout);
			fclose(stderr);

			/* Deploy wget */
		}
	
	}


* Read the URLs from the file
 * @param urls - the URLs to download
 */

void readUrls(vector<string>& urls)

/* Open the file */
/* The URL buffer */
/* Make sure the file was opened */
/* Read the entire file */
	while(!urlFile.eof())
	{
		/* Read the buffer */
		/* Are we at the end of the file */
		/* Close the file */

int main()
{
	
		
	/* Read the URL files */
	vector<string> urls;
	
	/* Read the URLs */
	readUrls(urls);
	
	/* Create child processes */
	create_children(urls);

	wait(NULL);
		
	return 0;	
	
}

