#pragma once

#include <string>

namespace Words
{
    class Sample
    {
    public:
        Sample(const std::wstring& name);

        const std::wstring& get_Name() const;

    private:
        std::wstring name_;
    };
}