#include "Sample.h"

using namespace std;
using namespace Words;

Sample::Sample(const wstring& name)
    : name_(name)
{
}

const wstring& Sample::get_Name() const
{
    return name_;
}