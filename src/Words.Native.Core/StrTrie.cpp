#include "StrTrie.h"

using namespace std;
using namespace Words;

StrTrie::StrTrie()
    : nodes_()
{
}

size_t StrTrie::size() const
{
    return nodes_.size();
}

void StrTrie::insert(const Str& value)
{
    nodes_.insert(make_pair(value, true));
}