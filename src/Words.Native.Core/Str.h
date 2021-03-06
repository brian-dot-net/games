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

        Str(const char* s);

        uint8_t length() const;

        Ch operator[](uint8_t index) const;

        Str operator+(Ch c) const;

        Str operator+(char c) const;

        Str& operator=(const Str& rhs);

        bool operator==(const Str& rhs) const;

        Str chop() const;

        size_t hash_code() const;

        std::string str() const;

    private:
        uint64_t data_;

        Str(uint64_t data);
    };

    std::ostream& operator<<(std::ostream& os, const Str& s);

    constexpr Ch operator "" _c(char c)
    {
        if ((c >= 'A') && (c <= 'Z'))
        {
            return c - 'A' + 1;
        }

        return 0;
    }
}

namespace std
{
    template<> struct hash<Words::Str>
    {
        size_t operator()(const Words::Str& s) const noexcept
        {
            return s.hash_code();
        }
    };
}