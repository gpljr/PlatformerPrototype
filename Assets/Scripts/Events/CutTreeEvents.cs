public class CutTreeEvents : GameEvent {
	public int TreeID;
	public bool isCut;
	public CutTreeEvents(int TreeID, bool isCut)
	{
		this.TreeID=TreeID;
		this.isCut=isCut;
	}
}
