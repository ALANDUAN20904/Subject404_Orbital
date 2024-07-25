using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AiStateId
{
    Patrol = 0,
    chasePlayer = 1,
    Caught = 2
}

//convenience for creating new Aistates
public interface AiState
{
      AiStateId GetId();
    void Enter(AiAgent agent);
    void Update(AiAgent agent);
    void Exit(AiAgent agent);
}
