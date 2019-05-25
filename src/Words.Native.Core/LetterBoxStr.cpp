#include "LetterBoxStr.h"

using namespace Words;

LetterBoxStr::LetterBoxStr(const Str& box)
    : box_(box)
{
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
    default:
        return Vertices(0b000111111111);
    }
}