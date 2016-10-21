﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GenerateCharactersSystem : IInitializeSystem
{
    Group tileEntities;

    public void Initialize()
    {
        tileEntities = Pools.sharedInstance.core.GetGroup(Matcher.AllOf(CoreMatcher.Tile, CoreMatcher.MapPosition));

        if (!Pools.sharedInstance.core.hasCharacters)
            Pools.sharedInstance.core.CreateEntity().AddCharacters(new PositionIndex(Pools.sharedInstance.core, Matcher.AllOf(CoreMatcher.Character, CoreMatcher.MapPosition)));

        Stack<string> characters = new Stack<string>();
        characters.Push("Leo");
        characters.Push("Ken");
        characters.Push("Alex");

        while(characters.Count > 0)
        {
            var characterEntity = Pools.sharedInstance.core.CreateEntity()
                .AddCharacter(characters.Pop())
                .AddMapPosition(tileEntities.GetEntities()[UnityEngine.Random.Range(0, tileEntities.count)].mapPosition.Position);
        }

    }
}

public class AddCharacterViewSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(CoreMatcher.Character, CoreMatcher.MapPosition).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var entity in entities)
        {
            var e = Pools.sharedInstance.view.CreateEntity();
            e.AddWorldPosition(MapUtilities.MapToWorldPosition(entity.mapPosition.Position));
            GameObject characterGO = GameObject.Instantiate(Resources.Load("Prefabs/Character"), e.worldPosition.Position + (Vector3.back*0.25f), Quaternion.identity) as GameObject;
            characterGO.name = entity.character.Name;
            var characterView = characterGO.AddComponent<CharacterView>();
            if (characterView)
            {
                characterView.Initialize(entity.mapPosition.Position);
                e.AddCharacterView(characterView);
                //e.AddSelectedListener(characterView);
            }
        }
    }
}
