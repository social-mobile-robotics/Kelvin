using System;
using System.Windows.Input;

namespace Kelvin.HardwareController {

    using Infrastructure.MVVM;
    using Infrastructure.Services;
    using IO;

    public class ChasisStateMachine : BindableBase {

        private object shared = new object();
        private ChasisState state;

        private ClockGenerationService generator;
        private SerialDataContext context;

        private ICommand engineOn, engineOff, move, turnLeft, turnRight;

        public Action<ChasisState> StateChanged;


        private void Initialize() {

        }

        private void ChangeState(
            ChasisState newState, StateMachineCommand newPlayCommand, StateMachineCommand newStopCommand, Action onNewState) {

            lock (shared) {
                state = newState;


                onNewState?.Invoke();
                StateChanged?.Invoke(state);
            }
        }

        private class StateMachineCommand : RelayCommand {

            internal string Name { get; }

            public StateMachineCommand(string name, Action<object> execute, Predicate<object> canExecute)
                : base(execute, canExecute) {
                Name = name;
            }
            public override string ToString() => Name;
        }
    }
}