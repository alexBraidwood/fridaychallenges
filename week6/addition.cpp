#include <iostream>
#include <vector>
#include <string>
#include <cstdlib>
#include <sstream>

using namespace std;


int to_int(std::string &s) {
  return atoi(s.c_str());
}

string getCarryOver(vector<int> numbers) {
  int results;
  int hold;
  string strResult;
  
  for (auto num : numbers) {
    results += num;
  }

  return strResult;
}

vector<int> numbers;
int total;

int main (int argc, char* argv[]) {
  if (argc < 1)
    return -1;

  char* additionString = argv[1];
  string currentNumber;
  
  while (*additionString) {

    if (*additionString == '-') {
      return -1;
    }
    
    if (*additionString != '+') {
      currentNumber += *additionString;
    } else {
      numbers.push_back(to_int(currentNumber));
      currentNumber.clear();
    }
    additionString++;
  }
  
  numbers.push_back(to_int(currentNumber));
  cout << getCarryOver(numbers) << endl;
  cout << "-------" << endl;
  
  for (auto num : numbers) {
    total += num;
    cout << num << endl;
  }

  cout << "-------" << endl << total << endl;

  return 0;
}


