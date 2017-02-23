using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IHide : IEventSystemHandler {

	void hide();
	void show();
	
}
