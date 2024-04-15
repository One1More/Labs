package ru.gorbunov.presentation.scripts;

import ru.gorbunov.presentation.Script;

public class Exit implements Script {
    @Override
    public String Name() {
        return "Exit.";
    }

    @Override
    public void run() {
        System.exit(0);
    }
}
