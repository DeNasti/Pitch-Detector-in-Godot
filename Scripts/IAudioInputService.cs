using PitchMaster.Entities;

namespace PitchMaster.Scripts
{
    public interface IAudioInputService
    {
        AudioInputStatusModel GetStatus();
    }
}
