using PitchMaster.Entities;

namespace PitchMaster.Scripts
{
    public interface IFrequenciesManager
    {
        float MinHeartz { get; }
        float MaxHeartz { get;  }
        string GetNoteNameFromFrequency(float frquenctHz);

    }
}