#include <linux/kernel.h>
#include <iostream>

asmlinkage long sys_hello(int n)
{
        printf("%d", n);
        printk("Hello world\n");
        return 0;
}
