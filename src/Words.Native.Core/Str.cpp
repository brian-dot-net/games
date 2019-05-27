#include "Str.h"

using namespace std;
using namespace Words;

Str Parse(const char* s)
{
    Str value;
    for (const char* p = s; *p; ++p)
    {
        value = value + *p;
    }

    return value;
}

Str::Str()
    : data_(0)
{
}

Str::Str(const char* s)
    : Str(Parse(s))
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
    if (index > 11)
    {
        throw range_error("Index out of range.");
    }

    return (data_ >> (4 + (5 * index))) & 0x1F;
}

Str Str::operator+(char c) const
{
    return operator+(operator "" _c(c));
}

Str Str::operator+(Ch c) const
{
    if (length() == 12)
    {
        throw range_error("String too long.");
    }

    uint64_t ch = c;
    ch <<= (4 + (5 * length()));
    return Str((ch | data_) + 1);
}

Str& Str::operator=(const Str& rhs)
{
    data_ = rhs.data_;
    return *this;
}

bool Str::operator==(const Str& rhs) const
{
    return data_ == rhs.data_;
}

Str Str::chop() const
{
    if (length() == 0)
    {
        throw range_error("String empty.");
    }

    uint64_t mask = ~(0x1FULL << (4 + ((length() - 1) * 5)));
    return Str((data_ & mask) - 1);
}

size_t Str::hash_code() const
{
    return data_;
}

string Str::str() const
{
    char chars[13];
    memset(chars, 0, sizeof(chars));
    for (uint8_t i = 0; i < length(); ++i)
    {
        chars[i] = 'A' - 1 + operator[](i);
    }

    return string(chars);
}

ostream& Words::operator<<(ostream& os, const Str& s)
{
    os << s.str();
    return os;
}
