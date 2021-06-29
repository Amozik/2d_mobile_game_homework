using AI.Player;

namespace AI.Enemies
{
    public interface IEnemy
    {
        void Update(DataPlayer dataPlayer, DataType dataType);
    }
}