#include "StrTrie.h"

using namespace std;
using namespace Words;

StrTrie::StrTrie()
    : nodes_(), size_(0)
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

    Map::iterator it = nodes_.find(value);
    if (it != nodes_.end())
    {
        if (it->second)
        {
            return;
        }

        it = nodes_.erase(it);
    }

    ++size_;
    nodes_.insert(it, make_pair(value, true));

    Str v = value;
    while (v.length() > 1)
    {
        v = v.chop();
        if (nodes_.find(v) != nodes_.cend())
        {
            return;
        }

        nodes_.insert(make_pair(v, false));
    }
}

StrTrie::NodeKind StrTrie::find(const Str& value) const
{
    const auto& it = nodes_.find(value);
    if (it == nodes_.cend())
    {
        return None;
    }

    return it->second ? Terminal : Prefix;
}