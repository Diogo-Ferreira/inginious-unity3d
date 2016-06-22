using System;

public interface IDeerState
{
	void updateState();
	void toRunAway();
	void toIdleState();
}

