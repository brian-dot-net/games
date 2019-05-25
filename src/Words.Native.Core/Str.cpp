#include "Str.h"

using namespace std;
using namespace Words;

Str::Str()
{
}

uint8_t Str::length() const
{
    return 0;
}

Ch Str::operator[](uint8_t index) const
{
    return '\0'_c;
}

ostream& Words::operator<<(ostream& os, const Str& s)
{
    return os;
}
