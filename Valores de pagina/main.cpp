#include <stdio.h>

int temp_data = 0;
static int temp_bss;

int main()
{
    int local_var = 0;
    int *code_segment_address = (int *)&print_addr;
    int *data_segment_address = &temp_data;
    int *bss_address = &temp_bss;
    int *stack_segment_address = &local_var;
    
    printf("Code Segment:     %10p\n", code_segment_address);
    printf("Data Segment:     %10p\n", data_segment_address);
    printf("BSS:              %10p\n", bss_address);
    printf("Stack Segment:      %10p\n", stack_segment_address);
    return 0;
}