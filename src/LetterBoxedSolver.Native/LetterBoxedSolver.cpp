#include <iostream>
#include "Str.h"

using namespace std;
using namespace Words;

int main()
{
    Str s;
    s = s + 'A'_c;

    size_t length = s.length();
    cout << "(" << length << ") [" << s << "]\r\n";

    return 0;
}
