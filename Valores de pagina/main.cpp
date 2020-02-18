#include <iostream>
#include <stdio.h>
#include <stdlib.h>

/* these are in no header file, and on some
systems they have a _ prepended 
These symbols have to be typed to keep the compiler happy
Also check out brk() and sbrk() for information
about heap */

extern char  etext, edata, end; 

int main(int argc, char **argv)
{
    printf("Code segment:      %10p\n", &etext);
    printf("Data segment:      %10p\n", &edata);
    printf("BSS:               %10p\n", &end);

    return EXIT_SUCCESS;
}