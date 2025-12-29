using UnityEngine;

public interface ICastable
{
    public void ToggleMagic(Vector2 position);

    public Color magicColor { get; }
}
