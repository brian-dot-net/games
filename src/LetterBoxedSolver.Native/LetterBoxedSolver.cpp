#include "Str.h"

using namespace std;
using namespace Words;

void Print(const Str& s)
{
    size_t length = s.length();
    cout << "(" << length << ") [" << s << "]\r\n";
}

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
    s = s + 'I'_c;
    s = s + 'J'_c;
    s = s + 'K'_c;
    s = s + 'L'_c;

    Print(s);

    Str t = "ZYXWVUTSRQPO";
    Print(t);

    return 0;
}
