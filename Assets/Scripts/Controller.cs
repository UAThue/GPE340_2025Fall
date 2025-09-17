using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;

    public virtual void Possess(Pawn pawnToPossess)
    {
        pawnToPossess.controller = this;
        pawn = pawnToPossess;
    }
}
