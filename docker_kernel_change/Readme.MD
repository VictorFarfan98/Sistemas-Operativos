# Es imposible cambiar el kernel de un contenedor de Docker debido a que esté no contiene un Kernel. Un contenedor de Docker se monta y hace uso del Kernel del SO host, por lo que para añadir un nuevo system call se tiene que modificar el kernel del SO host. 

## Pasos a seguir

* Descargar un kernel compatible para modificar, en la carpeta raiz crear una carpeta y dentro un archivo *.c con el contenido de la funcion a crear. 
* Crear un Makefile dentro de este misma carpeta
* Regresar a la carpeta raíz del kernel
* Abrir el archivo Makefile
* Buscar la linea: 
    * core-y += kernel/ mm/ fs/ ipc/ security/ crypto/ block/
    * Añadir la ruta *hello/* creada 
    * core-y += kernel/ mm/ fs/ ipc/ security/ crypto/ block/ hello/
* En la carpeta raiz del kernel ir a arch/x86/entry/syscalls y abrir el archivo syscalls_64.tbl (debido a que uso un SO de 64 bits)
* Regresar a la carpeta raiz del kernel
* Ir al directorio include/linux
* Abrir el archivo syscalls.h y añadir al final del archivo la funcion creada. En este ejemplo: asmlinkage long sys_hello(int);
* Instalar las dependencias necesarias para la compilacion 
    * sudo apt-get install gcc
    * sudo apt-get install libncurses5-dev
    * sudo apt-get install bison
    * sudo apt-get install flex
    * sudo apt-get install libssl-dev
    * sudo apt-get install libelf-dev
    * sudo apt-get update
    * sudo apt-get upgrade
* Ejecutar el comando:
    * sudo make menuconfig
    * Ir a file systems
    * Marcar todas las casillas que incluyan la palabra "ext4"
* Compilar el kernel con el comando
    * sudo make -jn (n=numero de threads del procesador)
* Instalar el kernel con el comando 
    * sudo make modules_install install
* Reiniciar el equipo
* Crear un archivo *test.c* con el cual probar el nuevo system call
* Si retornó con codigo 0, el system call funcionó correctamente 