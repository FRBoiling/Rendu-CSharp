using System.Collections.Generic;

namespace Entitas
{
    public class Entity
    {
        private static readonly Stack<ScoreComponent> _scoreComponentPool = new Stack<ScoreComponent>();
        public ScoreComponent score => (ScoreComponent) GetComponent(ComponentIds.Score);

        public bool hasScore => HasComponent(ComponentIds.Score);

        public static void ClearScoreComponentPool()
        {
            _scoreComponentPool.Clear();
        }

        public Entity AddScore(int newValue)
        {
            var component = _scoreComponentPool.Count > 0 ? _scoreComponentPool.Pop() : new ScoreComponent();
            component.value = newValue;
            return AddComponent(ComponentIds.Score, component);
        }

        public Entity ReplaceScore(int newValue)
        {
            var previousComponent = hasScore ? score : null;
            var component = _scoreComponentPool.Count > 0 ? _scoreComponentPool.Pop() : new ScoreComponent();
            component.value = newValue;
            ReplaceComponent(ComponentIds.Score, component);
            if (previousComponent != null) _scoreComponentPool.Push(previousComponent);
            return this;
        }

        public Entity RemoveScore()
        {
            var component = score;
            RemoveComponent(ComponentIds.Score);
            _scoreComponentPool.Push(component);
            return this;
        }
    }

    public class Pool
    {
        public Entity scoreEntity => GetGroup(Matcher.Score).GetSingleEntity();

        public ScoreComponent score => scoreEntity.score;

        public bool hasScore => scoreEntity != null;

        public Entity SetScore(int newValue)
        {
            if (hasScore) throw new SingleEntityException(Matcher.Score);
            var entity = CreateEntity();
            entity.AddScore(newValue);
            return entity;
        }

        public Entity ReplaceScore(int newValue)
        {
            var entity = scoreEntity;
            if (entity == null)
                entity = SetScore(newValue);
            else
                entity.ReplaceScore(newValue);

            return entity;
        }

        public void RemoveScore()
        {
            DestroyEntity(scoreEntity);
        }
    }

    public class Matcher
    {
        private static IMatcher _matcherScore;

        public static IMatcher Score
        {
            get
            {
                if (_matcherScore == null) _matcherScore = Matcher.AllOf(ComponentIds.Score);

                return _matcherScore;
            }
        }
    }
}