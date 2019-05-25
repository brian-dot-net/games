#include "StrTrie.h"

using namespace std;
using namespace Words;

StrTrie::StrTrie()
    : nodes_(), size_(0)
{
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

    if (nodes_.find(value) != nodes_.cend())
    {
        return;
    }

    ++size_;
    nodes_.insert(make_pair(value, true));

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