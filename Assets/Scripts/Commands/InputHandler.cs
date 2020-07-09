using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    List<Command> commands;

    // Start is called before the first frame update
    void Start()
    {
        commands = new List<Command>();
        commands.Add(new MonterCommand(KeyCode.LeftShift));
        commands.Add(new DescendreCommand(KeyCode.LeftControl));
        commands.Add(new AvancerCommand(KeyCode.Z));
        commands.Add(new ReculerCommand(KeyCode.S));
        commands.Add(new DroiteCommand(KeyCode.D));
        commands.Add(new GaucheCommand(KeyCode.Q));
        commands.Add(new JumpCommand(KeyCode.Space));
        commands.Add(new ActionCommand(KeyCode.E));
        commands.Add(new QuitCommand(KeyCode.A));
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<commands.Count; i++)
        {
            if(Input.GetKey(commands[i].GetKey()))
            {
                commands[i].Execute();
            }
        }
    }
}
