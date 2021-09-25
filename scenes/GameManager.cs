using Godot;
using PitchMaster.Scripts;
using System;

public class GameManager : Node
{
	Label _noteDisplayLabel;
	Label _hertzDisplayLabel;

	IAudioInputService _audioInputManager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var noteDisplay = GetNode("../UI/NoteDisplay/Label");
		var hertzDisplay = GetNode("../UI/HertzDisplay/Label");

		if (noteDisplay is Label labelNote)
		{
			_noteDisplayLabel = labelNote;
		}

		if (hertzDisplay is Label labelHz)
		{
			_noteDisplayLabel = labelHz;
		}

	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
		var status = _audioInputManager.GetStatus();

		_noteDisplayLabel.Text = status.Note;
		_hertzDisplayLabel.Text = status.Frequency;

	}
}
