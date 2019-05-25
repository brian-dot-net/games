#include "LetterBoxStr.h"

using namespace std;
using namespace Words;

LetterBoxStr::LetterBoxStr(const Str& box)
    : box_(box)
{
    if (box_.length() != 12)
    {
        throw range_error("Input must be length 12.");
    }
}

Ch LetterBoxStr::operator[](uint8_t index) const
{
    return box_[index];
}

Vertices LetterBoxStr::next(uint8_t start) const
{
    switch (start)
    {
    case 0:
    case 1:
    case 2:
        return Vertices(0b111111111000);
    case 3:
    case 4:
    case 5:
        return Vertices(0b111111000111);
    case 6:
    case 7:
    case 8:
        return Vertices(0b111000111111);
    case 9:
    case 10:
    case 11:
        return Vertices(0b000111111111);
    default:
        throw range_error("Index out of range.");
    }
}

ostream& Words::operator<<(ostream& os, const LetterBoxStr& s)
{
    os << s.box_;
    return os;
}