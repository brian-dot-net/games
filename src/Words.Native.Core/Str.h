#pragma once

#include <string>
#include <iostream>

namespace Words
{
    typedef uint8_t Ch;

    class Str
    {
    public:
        Str();

        uint8_t length() const;

        Ch operator[](uint8_t index) const;

        Str operator+(Ch c) const;

        Str& operator=(const Str& rhs);

        Str chop() const;

    private:
        uint64_t data_;

        Str(uint64_t data);
    };

    std::ostream& operator<<(std::ostream& os, const Str& s);

    constexpr Ch operator "" _c(char c)
    {
        if (c == 0)
        {
            return 0;
        }

        return c - 'A' + 1;
    }
}