#include <iostream>
#include "Str.h"

using namespace std;
using namespace Words;

int main()
{
    Str s;
    s = s + 'A'_c;
    s = s + 'B'_c;
    s = s + 'C'_c;
    s = s + 'D'_c;
    s = s + 'E'_c;
    s = s + 'F'_c;
    s = s + 'G'_c;
    s = s + 'H'_c;

    size_t length = s.length();
    cout << "(" << length << ") [" << s << "]\r\n";

    return 0;
}
