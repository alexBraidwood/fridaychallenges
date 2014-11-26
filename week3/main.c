#include <stdio.h>

void Cipher(char*, unsigned);
/* char* Decipher(char*); */

#define UPPERMIN_BOUND 'A'
#define UPPERMAX_BOUND 'Z'
#define LOWERMIN_BOUND 'a'
#define LOWERMAX_BOUND 'z'

int main (int argc, char* argv[]) {
  
  char* input;
  unsigned offset;
  printf("Please input a string: \n");
  scanf("%s", input);
  printf("Please input an even offset between 0 and 255: \n");
  scanf("%d", &offset);
  
  Cipher(input, offset);
  printf("After Cipher: %s", input);

}

unsigned char GetWrapAround(unsigned char currentValue) {  
  if (currentValue > LOWERMAX_BOUND) {
    unsigned char overage = currentValue - LOWERMAX_BOUND;
    if ((UPPERMIN_BOUND + overage) > UPPERMAX_BOUND) {
      return GetWrapAround(UPPERMIN_BOUND + overage);
    } else {
      return UPPERMIN_BOUND + overage;
    }
  }

  if (currentValue < UPPERMIN_BOUND) {
    unsigned char under = UPPERMIN_BOUND - currentValue;
    if ((UPPERMIN_BOUND + under) > UPPERMAX_BOUND) {
      return GetWrapAround(UPPERMIN_BOUND + under);
    } else {
      return UPPERMIN_BOUND + under;
    }
  }
  
  if (currentValue > UPPERMAX_BOUND && currentValue < LOWERMIN_BOUND) {
    unsigned char overage = currentValue - UPPERMAX_BOUND;
    if ((LOWERMIN_BOUND + overage) > LOWERMAX_BOUND) {
      return GetWrapAround(LOWERMIN_BOUND + overage);
    } else {
      return LOWERMIN_BOUND + overage;
    }
  }

  if (currentValue < LOWERMIN_BOUND) {
    if ((currentValue + 25) > LOWERMAX_BOUND) {
      return GetWrapAround(currentValue + 25);
    } else {
      return currentValue + 25;
    }
  }
}

void Cipher(char* input, unsigned offset) {
  printf("Before Cipher: ");
  while(*input != '\0') {
    printf("%c", *input);
    unsigned char nextChar = *input + offset;

    /* Wrap the Cipher if we're in between bounds */
    if (nextChar > UPPERMAX_BOUND && nextChar < LOWERMIN_BOUND){
      *input = GetWrapAround(nextChar);
    }
    else if (nextChar > LOWERMAX_BOUND || nextChar < UPPERMIN_BOUND) {
      *input = GetWrapAround(nextChar);
    }
    else {
      *input = nextChar;
    }
    input += 1;
  }
  printf("\n");
}
