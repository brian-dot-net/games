#include "Str.h"

using namespace std;
using namespace Words;

Str::Str()
    : data_(0)
{
}

Str::Str(uint64_t data)
    : data_(data)
{
}

uint8_t Str::length() const
{
    return data_ & 0xF;
}

Ch Str::operator[](uint8_t index) const
{
    return (data_ >> (4 + (5 * index))) & 0x1F;
}

Str Str::operator+(Ch c) const
{
    uint64_t ch = c << (4 + (5 * length()));
    return Str((ch | data_) + 1);
}

Str& Str::operator=(const Str& rhs)
{
    data_ = rhs.data_;
    return *this;
}

ostream& Words::operator<<(ostream& os, const Str& s)
{
    for (uint8_t i = 0; i < s.length(); ++i)
    {
        char c = 'A' - 1 + s[i];
        os << c;
    }

    return os;
}
