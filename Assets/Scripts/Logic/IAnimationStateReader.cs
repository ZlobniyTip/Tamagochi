using Assets.Scripts.Logic;

namespace Assets.Scripts.Logic
{
  public interface IAnimationStateReader
  {
    void EnteredState(int stateHash);
    void ExitedState(int stateHash);
    AnimatorState State { get; }
  }
}