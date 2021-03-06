﻿using Entitas;


public interface ISelectedListener
{
    void SelectedChanged(Entity selectedEntity);
}

[View, UI]
public class SelectedListenerComponent : IComponent
{
    public ISelectedListener Listener;
}

[Core]
public class IdComponent : IComponent
{
    public int Id;
}