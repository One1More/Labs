pluginManagement {
    plugins {
        kotlin("jvm") version "1.9.22"
    }
}
plugins {
    id("org.gradle.toolchains.foojay-resolver-convention") version "0.5.0"
}
rootProject.name = "Lab1"
include("banks-core")
include("banks-presentation")
include("cats-controller")
include("cats-service")
include("cats-dal")
include("cats-security")
include("cats-CatsMicroservice")
include("cats-OwnersMicroservice")
include("cats-CatsMicroservice:dal")
findProject(":cats-CatsMicroservice:dal")
include("cats-CatsMicroservice:controller")
findProject(":cats-CatsMicroservice:controller")
include("cats-CatsMicroservice:service")
findProject(":cats-CatsMicroservice:service")
include("cats-OwnersMicroservice:dal")
findProject(":cats-OwnersMicroservice:dal")
include("cats-OwnersMicroservice:controller")
findProject(":cats-OwnersMicroservice:controller")
include("cats-OwnersMicroservice:service")
findProject(":cats-OwnersMicroservice:service")
include("cats-apiGateway")
include("cats-apiGateway:security")
findProject(":cats-apiGateway:security")?.name = "security"
include("cats-CatsMicroservice:model")
findProject(":cats-CatsMicroservice:model")?.name = "model"
include("cats-OwnersMicroservice:model")
findProject(":cats-OwnersMicroservice:model")?.name = "model"
include("cats-OwnersMicroservice:client")
findProject(":cats-OwnersMicroservice:client")?.name = "client"
include("cats-CatsMicroservice:client")
findProject(":cats-CatsMicroservice:client")?.name = "client"
include("cats-apiGateway:controller")
findProject(":cats-apiGateway:controller")?.name = "controller"
include("cats-apiGateway:service")
findProject(":cats-apiGateway:service")?.name = "service"
include("cats-OwnersMicroservice:client")
findProject(":cats-OwnersMicroservice:client")?.name = "client"
include("cats-apiGateway:kafka")
findProject(":cats-apiGateway:kafka")?.name = "kafka"
include("cats-CatsMicroservice:kafka")
findProject(":cats-CatsMicroservice:kafka")?.name = "kafka"
include("cats-CatsMicroservice:kafka")
findProject(":cats-CatsMicroservice:kafka")?.name = "kafka"
include("cats-OwnersMicroservice:kafka")
findProject(":cats-OwnersMicroservice:kafka")?.name = "kafka"
include("cats-OwnersMicroservice:ownersClient")
findProject(":cats-OwnersMicroservice:ownersClient")?.name = "ownersClient"
include("cats-OwnersMicroservice:ownersModel")
findProject(":cats-OwnersMicroservice:ownersModel")?.name = "ownersModel"
include("cats-apiGateway:kafkaMessages")
findProject(":cats-apiGateway:kafkaMessages")?.name = "kafkaMessages"
include("cats-apiGateway:kafkaMessages")
findProject(":cats-apiGateway:kafkaMessages")?.name = "kafkaMessages"
