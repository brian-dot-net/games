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