﻿namespace Shared.Interfaces;

public interface IJsonService<TEntity>
{
    public List<TEntity>? Deserialize(string json);

    public string Serialize(List<TEntity> listOfObjects);
}
