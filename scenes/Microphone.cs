using Godot;
using PitchMaster.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;

public class Microphone : AudioStreamPlayer3D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private AudioEffectSpectrumAnalyzerInstance audioEffectSpectrumAnalyzer;
	private IFrequenciesManager _frequenciesManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var istance = AudioServer.GetBusEffectInstance(1, 1);

		if (istance is null)
		{
			GD.Print("GetBusEffectInstance is null");
		}

		if (istance is AudioEffectSpectrumAnalyzerInstance)
		{
			GD.Print("is AudioEffectSpectrumAnalyzerInstance");
			audioEffectSpectrumAnalyzer = (AudioEffectSpectrumAnalyzerInstance)istance;
		}

		_frequenciesManager = new FrequenciesManager();
	}

	float samples = 30f;
	float maxFreqency = 11050.0f;

	float totDelta = 0;
	float tickInterva = 1f;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{

		totDelta += delta;

		if (totDelta < tickInterva)
			return;

		totDelta = 0;

		var prev_hz = 0f;

		var hzWithMaxDb = new HzAndEnergy { hertz = -1, energy = -1 };

		var a = new List<HzAndEnergy>();

		for (int i = 1; i < samples + 1; i++)
		{
			float hz = i * (maxFreqency / samples);
			a.Add(sample(prev_hz, hz));
			prev_hz = hz;
		}

		var maxEnergy = a.Max(y => y.energy);
		var maxA = a.FirstOrDefault(x => x.energy == maxEnergy);
		var note = _frequenciesManager.GetNoteNameFromFrequency(maxA.hertz);

		GD.Print($"NOTE  [{note}] ");

		base._PhysicsProcess(delta);
	}

	public HzAndEnergy sample(float minHz, float maxHz) 
	{
		var magnitude = audioEffectSpectrumAnalyzer.GetMagnitudeForFrequencyRange(minHz, maxHz);
		var currentEnergy = magnitude.Length();
		//GD.Print($"frequent  [{minHz}-{maxHz}] energy [{currentEnergy}]");
		return new HzAndEnergy { hertz = maxHz, energy = currentEnergy };

	}


	public class HzAndEnergy
	{
		public float hertz { get; set; }
		public float energy { get; set; }

		public override string ToString() 
		{
			return $"hz : {hertz} - db: {energy}";
		}
	}
}
