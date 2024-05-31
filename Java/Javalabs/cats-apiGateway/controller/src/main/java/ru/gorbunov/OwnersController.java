package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/v1/owners")
public class OwnersController {
    private final OwnersService service;

    @Autowired
    public OwnersController(OwnersService service) {
        this.service = service;
    }

    @GetMapping
    @PreAuthorize("hasAuthority('ADMIN')")
    public List<OwnerReturnDto> getOwners() {
        return service.getOwners();
    }

    @PostMapping
    @PreAuthorize("hasAuthority('ADMIN')")
    public void addOwner(@RequestBody OwnerDto ownerDto) {
        service.addOwner(ownerDto);
    }

    @DeleteMapping("/{id}")
    @PreAuthorize("hasAuthority('ADMIN')")
    public void deleteOwner(@PathVariable("id") long id) {
        service.deleteOwner(id);
    }

    @PostMapping("owner/{id}/cat/{catId}")
    @PreAuthorize("hasAuthority('ADMIN')")
    public void addOwnerCat(@PathVariable("id") long id, @PathVariable("catId") long catId) {
        service.addOwnerCat(id, catId);
    }
}
