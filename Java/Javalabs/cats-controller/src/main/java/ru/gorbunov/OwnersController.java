package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import ru.gorbunov.contracts.OwnersService;
import ru.gorbunov.dto.OwnerDto;
import ru.gorbunov.dto.OwnerReturnDto;

import java.time.LocalDate;
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
    public List<OwnerReturnDto> getOwners() { return service.getOwners(); }

    @PostMapping
    public OwnerReturnDto addOwner(@RequestBody OwnerDto ownerDto) {
        return service.addOwner(ownerDto);
    }

    @DeleteMapping("/{id}")
    public void deleteOwner(@PathVariable("id") long id) {
        service.deleteOwner(id);
    }

    @PostMapping("owner/{id}/cat/{catId}")
    public void addOwnerCat(@PathVariable("id") long id, @PathVariable("catId") long catId) {
        service.addOwnerCat(id, catId);
    }
}
