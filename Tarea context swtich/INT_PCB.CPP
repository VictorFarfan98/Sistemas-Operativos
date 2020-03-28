#include <stdio.h>
#include <dos.h>
#include <conio.h>

#define INTR 0X1C
/* The clock tick interrupt */
//https://en.wikipedia.org/wiki/BIOS_interrupt_call
//http://stanislavs.org/helppc/int_table.html
//msinfo
#ifdef __cplusplus
    #define __CPPARGS ...
#else
    #define __CPPARGS
#endif

void interrupt ( *oldhandler)(__CPPARGS);
typedef void (*pcbHandler)();

int count=0;

struct PCB{
  int quantum;
  int quantumProgress;
  pcbHandler fn;
} ;
int x,y=0;

void func1(){
  x++;
}
void func2(){
 y= y+3;
}
PCB a,b, *current;
void interrupt handler(__CPPARGS)
{
/* increase the global counter */
   count++;
   current->quantumProgress++;
   if(current->quantumProgress>current->quantum)
   {
     if(current==&a)
     {
	current=&b;
     }  else {
       current=&a;
     }
     current->quantumProgress=0;
   }
/* call the old routine */
   oldhandler();
}

int main(void)
{
   int input;
   int CQ;
   int CQP;
   current = &a;
   a.quantum = 5;
   a.fn = func1;
   b.quantum = 3;
   b.fn = func2;
/* save the old interrupt vector */
   oldhandler = getvect(INTR);

/* install the new interrupt handler */
   setvect(INTR, handler);
   CQP=current->quantumProgress;
/* loop until the counter exceeds 20 */
   while (count < 20){
      CQ=current->quantum;
      CQP=current->quantumProgress;
      printf("count is x %d,y %d, count %d cq %d CQP %d\n", x, y,count, CQ, CQP);
   /*   if(count % 2==0)
      {
	current=&a;
      }
      else
      {
	current = &b;
      }
																													*/
      (*current).fn();
   }
/* reset the old interrupt handler */
   setvect(INTR, oldhandler);
   getch();
   return 0;
}