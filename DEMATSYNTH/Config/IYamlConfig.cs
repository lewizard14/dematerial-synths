using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMATSYNTH.Config;

public interface IYamlConfig
{
    void Save();
    static abstract string ConfigPath { get; }
}