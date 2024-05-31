package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.util.Pair;
import org.springframework.stereotype.Component;


import java.util.List;

@Component
public class OwnersService {
    private final OwnersClient client;
    private final KafkaProducer producer;

    @Autowired
    public OwnersService(OwnersClientImpl client, KafkaProducer producer) {
        this.client = client;
        this.producer = producer;
    }

    public List<OwnerReturnDto> getOwners() {
        return client.getOwners();
    }

    public void addOwner(OwnerDto ownerDto) {
        producer.sendMessage("add-owner", ownerDto);
    }

    public void deleteOwner(long id) {
        producer.sendMessage("delete-owner", id);

    }

    public void addOwnerCat(long id, long catId) {
        producer.sendMessage("delete-owner", new CatAndOwnerDto(catId, id));
    }
}
