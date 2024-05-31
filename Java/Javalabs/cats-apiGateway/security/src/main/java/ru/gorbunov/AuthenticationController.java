package ru.gorbunov;

import lombok.RequiredArgsConstructor;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import ru.gorbunov.dto.AuthenticationRequest;
import ru.gorbunov.dto.RegisterRequest;
import ru.gorbunov.services.AuthenticationService;

@RestController
@RequestMapping("/api/v1/auth")
@RequiredArgsConstructor
public class AuthenticationController {
    private final AuthenticationService service;

    @PostMapping("/register")
    @PreAuthorize("permitAll()")
    public void register(@RequestBody RegisterRequest request) {
        service.register(request);
    }

    @PostMapping("/authenticate")
    @PreAuthorize("permitAll()")
    public String authentication(@RequestBody AuthenticationRequest request) {
        return service.authenticate(request);
    }
}
