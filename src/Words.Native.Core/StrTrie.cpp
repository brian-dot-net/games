#include "StrTrie.h"

using namespace std;
using namespace Words;

StrTrie::StrTrie()
    : nodes_(0.5f), size_(0)
{
}

StrTrie::StrTrie(istream& stream)
    : StrTrie()
{
    char buffer[1024];
    Str value;
    bool skip = false;
    size_t length;
    do
    {
        stream.read(buffer, sizeof(buffer));
        length = stream.gcount();
        for (size_t i = 0; i < length; ++i)
        {
            char c = buffer[i];
            switch (c)
            {
            case '\r':
            case '\n':
                if (!skip && (value.length() > 2))
                {
                    insert(value);
                }

                value = Str();
                skip = false;
                break;
            default:
                if (!skip)
                {
                    if (value.length() == 12)
                    {
                        skip = true;
                    }
                    else
                    {
                        value = value + operator "" _c(c);
                    }
                }

                break;
            }
        }
    } while (length > 0);
}

size_t StrTrie::size() const
{
    return size_;
}

void StrTrie::insert(const Str& value)
{
    if (value.length() == 0)
    {
        return;
    }

    bool b;
    if (!nodes_.insert(value, true, &b))
    {
        if (!b)
        {
            ++size_;
        }

        return;
    }

    ++size_;
    Str v = value;
    while (v.length() > 1)
    {
        v = v.chop();
        bool prev;
        if (!nodes_.insert(v, false, &prev))
        {
            if (prev)
            {
                nodes_.insert(v, true);
            }

            return;
        }
    }
}

StrTrie::NodeKind StrTrie::find(const Str& value) const
{
    bool b;
    if (!nodes_.get(value, b))
    {
        return None;
    }

    return b ? Terminal : Prefix;
}