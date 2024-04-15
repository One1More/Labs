package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class Logout implements Script {
    private final CurrentUser currentUser;

    public Logout(CurrentUser currentUser) {
        this.currentUser = currentUser;
    }

    @Override
    public String Name() {
        return "Logout";
    }

    @Override
    public void run() {
        currentUser.user = Optional.empty();
    }
}
