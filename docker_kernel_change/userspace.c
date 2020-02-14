#include <stdio.h>
#include <linux/kernel.h>
#include <sys/syscall.h>
#include <unistd.h>
int main()
{
	 int n;
    printf("Ingrese un numero: ");
    scanf("%d", &n);
    printf("%d\n", n);
	
         printf("System call sys_hello returned 0\n");
         return 0;
}
