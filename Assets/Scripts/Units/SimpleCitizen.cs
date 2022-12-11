public class SimpleCitizen : Citizen {

    public override void InitBehaviours() {
        _citizenAnimation.SetIsMovingBool(true);
        _movement = new MoveFromPointToPoint(_agent, _movePoint, _stat.GetStatByType(StatsType.MoveSpeed));
    }
}