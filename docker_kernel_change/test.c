#include <stdio.h>
#include <linux/kernel.h>
#include <sys/syscall.h>
#include <unistd.h>
int main()
{
     	int n;
    printf("Ingrese un numero: ");
    scanf("%d", &n);
         long int amma = syscall(548, n);
         printf("System call sys_hello returned %ld\n", amma);
         return 0;
}
