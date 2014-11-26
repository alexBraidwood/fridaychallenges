#include <stdio.h>

int main (int argc, char* argv[]) {
  
  char* input = "Hello";
  printf("Please input a string: \n");
  /* scanf("%s", input); */

  while(*input != '\0') {
    printf("%c", *input);
    input += 1;
  }
  printf("\n");
}
