using PitchMaster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PitchMaster.Scripts
{
    public class FrequenciesManager : IFrequenciesManager
    {
        readonly List<NoteFrequencyModel> notes = new List<NoteFrequencyModel>();

        public float MinHeartz => 82.41f;
        public float MaxHeartz => 659.25f;

        public string GetNoteNameFromFrequency(float frquenctHz)
        {
            Godot.GD.Print($"cur = {frquenctHz} - min {MinHeartz}");


            var closerHz = ClosestTo(notes.Select(x => x.FrequencyHz), frquenctHz);

            Godot.GD.Print($"closer = {closerHz}");
            var result = notes.FirstOrDefault(x => x.FrequencyHz == closerHz);

            return result is null ? "NaN" : result.NoteName;
        }


        public static float ClosestTo(IEnumerable<float> collection, float target)
        {
            // NB Method will return int.MaxValue for a sequence containing no elements.
            // Apply any defensive coding here as necessary.
            var closest = float.MaxValue;
            var minDifference = float.MaxValue;
            foreach (var element in collection)
            {
                var difference = Math.Abs((double)element - target);
                if (minDifference > difference)
                {
                    minDifference = (float)difference;
                    closest = element;
                }
            }

            return closest;
        }


        public FrequenciesManager()
        {
            notes.Add(new NoteFrequencyModel { FrequencyHz = 82.41f, NoteName = "E2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 87.31f, NoteName = "F2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 92.50f, NoteName = "F#2/Gb2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 98.00f, NoteName = "G2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 104.23f, NoteName = "G#2/Ab2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 110.00f, NoteName = "A2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 116.54f, NoteName = "A#2/Bb2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 123.47f, NoteName = "B2" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 131.21f, NoteName = "C3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 138.59f, NoteName = "C#3/Db3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 147.23f, NoteName = "D3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 155.56f, NoteName = "D#3/Eb3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 165.21f, NoteName = "E3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 175.01f, NoteName = "F3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 185.00f, NoteName = "F#3/Gb3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 196.00f, NoteName = "G3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 208.05f, NoteName = "G#3/Ab3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 220.00f, NoteName = "A3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 233.08f, NoteName = "A#3/Bb3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 247.34f, NoteName = "B3" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 262.03f, NoteName = "C4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 277.18f, NoteName = "C#4/Db4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 294.06f, NoteName = "D4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 311.13f, NoteName = "D#4/Eb4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 330.03f, NoteName = "E4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 349.23f, NoteName = "F4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 370.39f, NoteName = "F#4/Gb4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 392.00f, NoteName = "G4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 415.30f, NoteName = "G#4/Ab4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 440.00f, NoteName = "A4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 466.16f, NoteName = "A#4/Bb4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 494.28f, NoteName = "B4" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 523.25f, NoteName = "C5" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 554.37f, NoteName = "C#5/Db5" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 587.33f, NoteName = "D5" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 622.25f, NoteName = "D#5/Eb5" });
            notes.Add(new NoteFrequencyModel { FrequencyHz = 659.25f, NoteName = "E5" });
        }


    }
}
